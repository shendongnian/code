    using (WebBrowser browser = new WebBrowser())
                {
                    browser.ScriptErrorsSuppressed = true;
                    browser.DocumentText = @"<html><head/><body><input id=""abc"" value=""this is the value in input""></body></html>";
                    // Wait for control to load page
                    while (browser.ReadyState != WebBrowserReadyState.Complete)
                        Application.DoEvents();
                    dynamic d = (dynamic)browser.Document.DomDocument;//get de activex dom
                    var jengine = new Jint.Engine();
                    jengine.SetValue("document", d);
                    try
                    {
                        string val=jengine.Execute(@"var a=document.getElementById('abc').value;").GetValue("a").ToString(); 
                        Console.WriteLine(val);
                    }
                catch (Jint.Runtime.JavaScriptException je)
                {
                    Console.WriteLine(je);
                }
            }
