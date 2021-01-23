        processCMD("bcp", String.Format("\"select 'COUNTRY', 'MONTH' union all SELECT COUNTRY, cast(MONTH as varchar(2)) FROM DBName.dbo.TableName\" queryout {0}FILE_NAME.csv -c -t; -T -{1}", ExportDirectory, SQLServer));
        
        
        static void processCMD(string fileName, string arguments) 
                {
        
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = fileName;
                    proc.StartInfo.Arguments = arguments;
                    proc.Start();
                    proc.WaitForExit();
                
                }
