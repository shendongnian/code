                    dynamic document = (JSObject)webControl1.ExecuteJavascriptWithResult("document.getElementsByClassName(\"badge\")[1]");
                    string gg = document.innerText;
                    personcount = Convert.ToInt16(gg);
                    int odd = rnd.Next(1, personcount * 2);
                    for (int i = 0;odd % 2 == 0;i++)
                    {
                        odd = rnd.Next(1, personcount * 2);
                    }
                    dynamic document2 = (JSObject)webControl1.ExecuteJavascriptWithResult("document.getElementsByClassName('name')["+odd+"]");
                    using (document2)
                    {
                        if (document2.HasMethod("click"))
                        {
                            document2.Invoke("click");
                            stepcount = 2;
                        }
                    }
