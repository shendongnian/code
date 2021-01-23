    using System;
    using System.Collections.Generic;
    using SeasideResearch.LibCurlNet;
    
    namespace libcurlFtpsExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("libcurlFtpsExample...");
    
                const string url = "ftp://user:thepassword@ftp.somesite.com/dir/";
    
                try
                {
                    Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);
    
                    Easy easy = new Easy();
                    if (easy != null)
                    {
                        easy.SetOpt(CURLoption.CURLOPT_URL, url);
                        easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYPEER, false);
                        easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYHOST, false);
                        easy.SetOpt(CURLoption.CURLOPT_FTP_SSL, CURLftpSSL.CURLFTPSSL_TRY);
    
                        // For debugging will print headers to console.
                        Easy.HeaderFunction hf = new Easy.HeaderFunction(OnHeaderData);
                        easy.SetOpt(CURLoption.CURLOPT_HEADERFUNCTION, hf);
                        
                        // For debugging will print received data to console.
                        Easy.DebugFunction df = new Easy.DebugFunction(OnDebug);
                        easy.SetOpt(CURLoption.CURLOPT_DEBUGFUNCTION, df);
                        easy.SetOpt(CURLoption.CURLOPT_VERBOSE, true);
         
                        // List directory only
                        easy.SetOpt(CURLoption.CURLOPT_FTPLISTONLY, true);
             
                        CURLcode code = easy.Perform();
                        if (code != CURLcode.CURLE_OK)
                        {
                            Console.WriteLine("Request failed!");
                        }
    
                        easy.Cleanup();
                    }
                    else
                    {
                        Console.WriteLine("Failed to get Easy libcurl handle!");
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp);
                }
                finally
                {
                    Curl.GlobalCleanup();
                }
            }
    
            public static void OnDebug(CURLINFOTYPE infoType, String msg, Object extraData)
            {
                // print out received data only
                if (infoType == CURLINFOTYPE.CURLINFO_DATA_IN)
                    Console.WriteLine(msg);
            }
    
            public static Int32 OnHeaderData(Byte[] buf, Int32 size, Int32 nmemb, Object extraData)
            {
                Console.Write(System.Text.Encoding.UTF8.GetString(buf));
                    return size * nmemb;
            }
        }
    }
