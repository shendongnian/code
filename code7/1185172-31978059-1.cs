    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.ComponentModel;
    using System.Data;
    using ClearCanvas.Dicom;
    using System.IO;
    using System.Diagnostics;
    using ClearCanvas.Dicom.Network;
    using ClearCanvas.Common;
    using System.Net;
    using System.Threading;
    namespace CC_SendFile
    {
        class Program
        {
    
            public static Boolean C_Store_Response = false;
            public static Boolean Assoc_Accept_Reject = false;
            public static Boolean NetworkError = false;
    
    
            public static String FilePath = null;
            public static String LocalAE = null;
            public static String RemoteAE = null;
            public static String RemoteIP = null;
            public static String RemotePort = null;
            public static uint MaxPDUSize = 0;
            public static int MaxPDUTimeoutMilliSeconds = 30000;
    
    
    
            static void Main(string[] args)
            {
    
                if (args.Length != 0)
                {
                    String ProcessID = null;
                    System.Diagnostics.Process myProcess = System.Diagnostics.Process.GetCurrentProcess();
                    ProcessID = "[" + myProcess.Id.ToString() + "] ";
                    myProcess.Close();
                    myProcess.Dispose();
    
                    Platform.Log(LogLevel.Debug, "Process ID obtained for title bar and logging is: " + ProcessID);
                    log4net.GlobalContext.Properties["procid"] = ProcessID;    
    
    
                    for (int i = 0; i < args.Length - 1; i++)
                    {
                        String ArgTemp = null;
    
                        ArgTemp = args[i];
    
                        if (ArgTemp == "-l")
                        {
                            LocalAE = args[i + 1];
                            i++;
                        }
                        if (ArgTemp == "-r")
                        {
                            RemoteAE = args[i + 1];
                            i++;
                        }
                        if (ArgTemp == "-h")
                        {
                            RemoteIP = args[i + 1];
                            i++;
                        }
                        if (ArgTemp == "-p")
                        {
                            RemotePort = args[i + 1];
                            i++;
                        }
                        if (ArgTemp == "-f")
                        {
                            FilePath = args[i + 1];
                            i++;
                        }
                        if (ArgTemp == "-u")
                        {
                            MaxPDUSize = uint.Parse(args[i + 1]);
                            i++;
                        }
                        if (ArgTemp == "-n")
                        {
                            MaxPDUTimeoutMilliSeconds = int.Parse(args[i + 1]);
    
                        }
    
    
                    }//for (int i = 1; i < args.Length - 1; i++)
    
    
                    ClientAssociationParameters g_assocParams = null;
                    DicomClient g_dicomClient = null;
    
                    IPAddress addr = null;
                    foreach (IPAddress dnsAddr in Dns.GetHostAddresses(RemoteIP))
                        if (dnsAddr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            addr = dnsAddr;
                            Platform.Log(LogLevel.Info , "IP address found to use is: " + addr.ToString());
                            break;
                        }
                    if (addr == null)
                    {
                        Platform.Log(LogLevel.Error, "No Valid IP addresses for host {0}", RemoteIP);
                        return;
                    }
                    g_assocParams = new ClientAssociationParameters(LocalAE, RemoteAE, new IPEndPoint(addr, int.Parse(RemotePort)));
    
    
                    if (MaxPDUSize != 0)
                    {
    
                        g_assocParams.LocalMaximumPduLength = MaxPDUSize;
    
                        Console.WriteLine("LocalMaximumPduLength has been set to: " + g_assocParams.LocalMaximumPduLength.ToString());
                        Platform.Log(LogLevel.Info, "LocalMaximumPduLength has been set to: " + g_assocParams.LocalMaximumPduLength.ToString());
                    }
                    else
                    {
                        Console.WriteLine("LocalMaximumPduLength is by default: " + g_assocParams.LocalMaximumPduLength.ToString());
                        Platform.Log(LogLevel.Info, "LocalMaximumPduLength is by default: " + g_assocParams.LocalMaximumPduLength.ToString());
                    }
    
    
                    try
                    {       
                        Console.WriteLine("");
                        Console.WriteLine("Loading File: " + FilePath + ", please wait...");
                        Console.WriteLine("");
                        Platform.Log(LogLevel.Info, "Loading File: " + FilePath + ", please wait...");
    
                        DicomFile DF = new DicomFile(FilePath);
    
    
                        GC.AddMemoryPressure(1047881834);
    
                        try
                        {
                            //DF.Load(DicomReadOptions.KeepGroupLengths);
                            DF.Load(DicomReadOptions.Default);
                        }
                        catch (Exception eL)
                        {
    
                        }
    
                        Console.WriteLine("SOP Class: " + DF.SopClass.ToString());
                        Console.WriteLine("Transfer Syntax: " + DF.TransferSyntax.ToString ());
                        Platform.Log(LogLevel.Info, "SOP Class: " + DF.SopClass.ToString());
                        Platform.Log(LogLevel.Info, "Transfer Syntax: " + DF.TransferSyntax.ToString());
    
                        byte pcid = g_assocParams.AddPresentationContext(DF.SopClass);
                        g_assocParams.AddTransferSyntax(pcid, DF.TransferSyntax);
    
    
                        DicomMessage msg = new DicomMessage(DF);
    
                        DF = null;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
    
                        AssociationHandler handler = new AssociationHandler();                  
                        Console.WriteLine("Attempting to connect to remote AE.");
                        Platform.Log(LogLevel.Info, "Attempting to connect to remote AE.");
                        g_dicomClient = DicomClient.Connect(g_assocParams, (IDicomClientHandler)handler);
                        
    
                        while (Assoc_Accept_Reject == false)
                        {
                            Console.WriteLine("Waiting for Association to be accepted or rejected.");
                            Platform.Log(LogLevel.Info, "Waiting for Association to be accepted or rejected.");
                            Thread.Sleep(1000);
    
                        }
    
                        try
                        {
                            if (MaxPDUTimeoutMilliSeconds != 0)
                            {
                                g_dicomClient.InternalSocket.SendTimeout = MaxPDUTimeoutMilliSeconds;
                                g_dicomClient.InternalSocket.ReceiveTimeout = MaxPDUTimeoutMilliSeconds;
                                Console.WriteLine("Internal Socket Send/Receive Timeout has been set to: " + g_dicomClient.InternalSocket.SendTimeout.ToString() + " ms.");
                                Platform.Log(LogLevel.Info, "Internal Socket Send/Receive Timeout has been set to: " + g_dicomClient.InternalSocket.SendTimeout.ToString() + " ms.");
                                g_dicomClient.InternalSocket.SendTimeout = MaxPDUTimeoutMilliSeconds;
                            }
                            Console.WriteLine("Sending C-Store Request.");
                            Platform.Log(LogLevel.Info, "Sending C-Store Request.");
    
                            g_dicomClient.SendCStoreRequest(pcid, g_dicomClient.NextMessageID(), DicomPriority.Medium, msg);
                        }
                        catch (Exception eS)
                        {
                            Console.WriteLine("Error sending C-Store Request.");
                            Console.WriteLine(eS.ToString());
                            Platform.Log(LogLevel.Error, "Error sending C-Store Request. The error is: " + eS.ToString ());
    
                        }
    
                        while (C_Store_Response == false)
                        {
    
                            Console.WriteLine("Waiting for C-Store response.");
                            Platform.Log(LogLevel.Info, "Waiting for C-Store response.");
                            Thread.Sleep(1000);
                            
                        }
    
                        if (NetworkError == false)
                        {
    
                            Console.WriteLine("Sending release request.");
                            Platform.Log(LogLevel.Info, "Sending release request.");
                            g_dicomClient.SendReleaseRequest();
    
                        }
    
                        Thread.Sleep(1000);
    
                        Console.WriteLine("Operations have completed.");
                        Console.WriteLine("Press ENTER to exit!");
                        Console.ReadLine();
    
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error reading file. The error is:");
                        Console.WriteLine("");
                        Console.WriteLine(e.Message);
                        Console.WriteLine("");
                        Console.WriteLine("Stack Trace:");
                        Console.WriteLine(e.ToString());
                        Console.WriteLine("Press ENTER to exit!");
                        Console.ReadLine();
    
                        Platform.Log(LogLevel.Error, "Error reading file. The error is:");
                        Platform.Log(LogLevel.Error, e.ToString());
                    }
    
                }//if (args .Length != 0 )
                else
                {
                    Console.WriteLine ("You must provide the proper command line arguments.");
                    Console.WriteLine ("Required arguments are:");
                    Console.WriteLine ("");
                    Console.WriteLine ("-f [full file path to DCM file] (No whitespaces please!)");
                    Console.WriteLine ("-l [Local AE Title]");
                    Console.WriteLine ("-r [Remote AE Title]");
                    Console.WriteLine ("-h [Remote HostName or IP address]");
                    Console.WriteLine ("-p [Remote Port]");
                    Console.WriteLine ("");
                    Console.WriteLine("Press ENTER to exit!");
                    Console.ReadLine();
    
                    Platform.Log(LogLevel.Error, "You must provide the proper command line arguments.");
                    Platform.Log(LogLevel.Error, "Required arguments are:");
                    Platform.Log(LogLevel.Error, "");
                    Platform.Log(LogLevel.Error, " -f [full file path to DCM file] (No whitespaces please!)");
                    Platform.Log(LogLevel.Error, " -l [Local AE Title]");
                    Platform.Log(LogLevel.Error, " -r [Remote AE Title]");
                    Platform.Log(LogLevel.Error, " -h [Remote HostName or IP address]");
                    Platform.Log(LogLevel.Error, " -p [Remote Port]");
                    Platform.Log(LogLevel.Error, "");
    
                }
    
            }//static void Main(string[] args)
    
    
    
    
            class AssociationHandler : IDicomClientHandler
            {
                #region IDicomClientHandler Members
    
                public void OnReceiveAssociateAccept(DicomClient client, ClientAssociationParameters association)
                {
                    Console.WriteLine("Association was accepted!");
                    Platform.Log(LogLevel.Info, "Association was accepted!");
                    Assoc_Accept_Reject = true;
                }
    
                public void OnReceiveAssociateReject(DicomClient client, ClientAssociationParameters association, DicomRejectResult result, DicomRejectSource source, DicomRejectReason reason)
                {
                    Console.WriteLine("Association was rejected!");
                    Platform.Log(LogLevel.Info, "Association was rejected!");
                    Assoc_Accept_Reject = true;
                }
    
                public void OnReceiveRequestMessage(DicomClient client, ClientAssociationParameters association, byte presentationID, DicomMessage message)
                {
    
                }
    
                public void OnReceiveResponseMessage(DicomClient client, ClientAssociationParameters association, byte presentationID, DicomMessage message)
                {
                    if (message.Status.Status == DicomState.Success)
                    {
                        Console.WriteLine("DICOM success message received!");
                        Platform.Log(LogLevel.Info, "DICOM success message received!");
                        C_Store_Response = true;
                    }
    
                    if (message.Status.Status != DicomState.Failure)
                    {
                        Console.WriteLine("DICOM faliure message received!");
                        Platform.Log(LogLevel.Info, "DICOM faliure message received!");
                        C_Store_Response = true;
                    }
                }
    
                public void OnReceiveReleaseResponse(DicomClient client, ClientAssociationParameters association)
                {
                    Console.WriteLine("Received Release Response.");
                    Platform.Log(LogLevel.Info, "Received Release Response.");
                }
    
                public void OnReceiveAbort(DicomClient client, ClientAssociationParameters association, DicomAbortSource source, DicomAbortReason reason)
                {
    
                }
    
                public void OnNetworkError(DicomClient client, ClientAssociationParameters association, Exception e)
                {
                    Console.WriteLine("Network Error occured.");
                    Platform.Log(LogLevel.Info, "Network Error occured.");
    
                    try
                    {
                        Platform.Log(LogLevel.Info, "Attempting to get error message...");
                        Platform.Log(LogLevel.Error, e.ToString ());
                    }
                    catch (NullReferenceException)
                    {
                        Platform.Log(LogLevel.Error, "The error message was null.");
                    }
    
                    C_Store_Response = true;
                    NetworkError = true;
                }
    
                public void OnDimseTimeout(DicomClient client, ClientAssociationParameters association)
                {
                    Platform.Log(LogLevel.Error, "DimseTimeout occured on client. Continuing...");
                }
    
                #endregion
    
            }
        }//class Program
    }//namespace CC_SendFile
