                    context.ExecuteQuery();
                }
                catch (Exception ex)
                {
                }
                var file = web.GetFileByServerRelativeUrl(new Uri(<FILE_URL>).AbsolutePath);
                context.Load(file);
                try
                {
                    context.ExecuteQuery();
                    file.SaveBinary(new SP.FileSaveBinaryInformation() { Content = Encoding.UTF8.GetBytes(<NEW_FILE>) });
                    try
                    {
                        context.ExecuteQuery();
                    }
                    catch (Exception ex)
                    {
                    }`
