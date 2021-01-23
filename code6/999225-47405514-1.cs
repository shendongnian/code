    if (theDoc.Body.InnerHtml != null)
                            {
                                try
                                {
                                    webBrowser1.Document.Window.ScrollTo(0, webBrowser1.Document.Body.ScrollRectangle.Height);
                                    timer2.Enabled = true;
                                }
                                catch { }
                            }
                            else
                            {
                                timer2.Enabled = true;
                            }
