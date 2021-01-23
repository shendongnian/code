    using System;
    using System.IO;
    
    namespace Features.Helper
    {
        /// <summary>
        ///     Class to create log information
        /// </summary>
        public class LogHelper
        {
            # region "Declarations"
    
            private readonly FileInfo _logFileInfo;
            private readonly long _maxLogFileSize = 0;
            private const string _strLineBreak = "\n========================\n";
            private const string _strLineBreakCustom = "\n*********************************\n\n\n\n";
            private const string _strLineBreakEnd = "\n----------------------------------------------------------\n\n\n";
            private readonly string _strLogFilePath;
    
            # endregion
    
            public static LogHelper objLog;
    
            public static LogHelper Instance
            {
                get {
                    return objLog ?? (objLog = new LogHelper(AppDomain.CurrentDomain.BaseDirectory + "Log\\log.txt", 0));
                }
            }      
            public static LogHelper PaymentInstance
            {
                get {
                    return objLog ??
                           (objLog =
                               new LogHelper(AppDomain.CurrentDomain.BaseDirectory + "Log\\PaymentResponse.txt", 0));
                }
            }
    
            # region "Constructors"
    
            /// <summary>
            ///     No-argument constructor
            /// </summary>
            public LogHelper()
            {
            }
    
            /// <summary>
            ///     Log class used to write exception details or
            ///     other specific details into a text file.
            /// </summary>
            /// <param name="strLogFilePath">Full path of the log file including filename</param>
            /// <param name="maxLogFileSize">
            ///     Maximum Log Size that can be acccomodated on the disk.
            ///     (number of Bytes as Long).
            ///     Log will be deleted/cleared if size exceeds.
            ///     Pass 0 for NO LIMIT on filesize
            /// </param>
            public LogHelper(string strLogFilePath, long maxLogFileSize)
            {
                _maxLogFileSize = maxLogFileSize;
                _strLogFilePath = strLogFilePath;
                _logFileInfo = new FileInfo(strLogFilePath);
            }
    
            # endregion
    
            # region "Methods"
    
            /// <summary>
            ///     Checks the log size
            ///     -- Deletes the file if maximum size is being reached.
            /// </summary>
            /// <returns>true->if logsize has reached maximum, false-> otherwise</returns>
            private bool CheckLogSize()
            {
                try
                {
                    if (_maxLogFileSize != 0)
                    {
                        if (_logFileInfo.Length > _maxLogFileSize)
                        {
                            File.Delete(_strLogFilePath);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
    
            /// <summary>
            ///     Writes exceptions to log files
            /// </summary>
            /// <param name="ex">Pass the exception ex as parameter.</param>
            /// <returns>Returns false if an exception occurs while writing to file</returns>
            public bool Write(Exception ex, string userdetails = null)
            {
                try
                {
                    CheckLogSize();
                    if (File.Exists(_strLogFilePath))
                    {
                        File.AppendAllText(_strLogFilePath, DateTime.UtcNow.ToString()
                                                            + " : Exception :"
                                                            + ex.Message + "\n"
                                                            + "Inner Exception : " + _strLineBreak
                                                            + ex.InnerException + "\n"
                                                            + "Stack Trace :" + _strLineBreak
                                                            + ex.StackTrace + "\n"
                                                            + "Date:" + _strLineBreak
                                                            + DateTime.Now.ToString() + "\n"
                                                            + " UserDetails :" + userdetails
                                                            + "Source : " + _strLineBreak
                                                            + ex.Source + _strLineBreakEnd);
                        return true;
                    }
                    File.WriteAllText(_strLogFilePath, DateTime.UtcNow.ToString()
                                                       + " : Exception :" + _strLineBreak
                                                       + ex.Message + "\n"
                                                       + "Inner Exception :" + _strLineBreak
                                                       + ex.InnerException + "\n"
                                                       + "Stack Trace :" + _strLineBreak
                                                       + ex.StackTrace + "\n"
                                                       + "Date:" + _strLineBreak
                                                       + DateTime.Now.ToString() + "\n"
                                                       + " UserDetails :" +  userdetails
                                                       + "Source :" + _strLineBreak
                                                       + ex.Source + _strLineBreakEnd);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
    
            ///// <summary>
            /////     Write custom strings apart from exceptions
            ///// </summary>
            ///// <param name="strMessage">Message to write to the file</param>
            ///// <param name="userdetails">user login details</param>
            ///// <returns>true->is successful, false-> otherwise</returns>
            public bool Write(string strMessage, string userdetails = null)
            {
                try
                {
                    if (File.Exists(_strLogFilePath))
                    {
                        File.AppendAllText(_strLogFilePath, _strLineBreak
                                                            + DateTime.UtcNow.ToString()
                                                            + "; UserDetails :" +  userdetails
                                                            + " : " + strMessage + _strLineBreakCustom);
                        return true;
                    }
                    File.WriteAllText(_strLogFilePath, _strLineBreak
                                                       + DateTime.UtcNow.ToString()
                                                       + "; UserDetails :" +  userdetails
                                                       + " : " + strMessage + _strLineBreakCustom);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            # endregion       
        }
    }
