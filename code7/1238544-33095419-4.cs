         public async CSPFEnumration.ProcedureResult GenerateFaxFile(string Daftar_No, string Channelno, string NationalCode)
                {
                        -----
                        // I want to make a pause in here without locking UI
                      AsyncWaitMethod();
                        -----
                }
         private static async Task AsyncWaitMethod()
               {
                    await Task.Delay(2000);
               }
