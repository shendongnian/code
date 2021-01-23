    private void sendDbViaEmail(object sender, EventArgs e)
        {
            if (File.Exists(Application.Instance.Config.OnePath))
            {
                try
                {
                    string zipFilename = Path.Combine(Path.GetDirectoryName(Application.Instance.Config.OnePath),
                        Path.GetFileNameWithoutExtension(Application.Instance.Config.OnePath) + ".zip");
                    try
                    {
                        if (File.Exists(zipFilename))
                            File.Delete(zipFilename);
                    }
                    catch { }
                    using (var zip = ZipStorer.Create(zipFilename,
                        string.Format("Agente {0}", Application.Instance.Config.CodAge)))
                    {
                        zip.AddFile(ZipStorer.Compression.Deflate, Application.Instance.Config.OnePath, Path.GetFileName(Application.Instance.Config.OnePath), "");
                    }
                   
               
                    string body = string.Format("OneMobile Lite - agente: {0} {1}", // ??
                                    Application.Instance.Config.CodAge,
                                    Application.Instance.Config.TbAgente != null ? Application.Instance.Config.TbAgente.Des : "n/a");
                    //  System.Net.Mail.Attachment attachment = null;
                    //attachment = new System.Net.Mail.Attachment("zipFilename");
               
                    var result = DependencyService.Get<IEmailService>().Send("erinolda.bregu@fshnstudent.info", "OneMobile Lite: Database file", body + " " + zipFilename );
                  
                    if (result == null)
                    {
                        // TODO cambiare API ServiceCommand.Execute() e non ServiceResult :)
                        App.Navigation.PopModalAsync(true);
                    }
                    else
                    {
                        result.Finished += (object s, EventArgs a) =>
                        {
                            App.Navigation.PopModalAsync(true);
                        };
                    }
                }
                catch (Exception ex)
                {
                    Application.Instance.Messages.Error(ex);
                }
            }
        }
