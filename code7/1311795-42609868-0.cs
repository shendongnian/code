    using (WebBrowser wb = new WebBrowser())
            {
                wb.Navigate("google.com");
                if (wb.Document != null)
                {
                    //get your (clickable) element, for ex. the submit button.
                    var el = wb.Document.GetElementById("email");
                    if (el != null)
                        el.InvokeMember("click");
                    else
                        Console.WriteLine("element not found!");
                }
                else
                    Console.WriteLine("could not load document!");
            }
