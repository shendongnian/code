      ViewEngines.Engines.Add(new RazorViewEngine
                {
                    PartialViewLocationFormats = new string[]
                    {
                        "~/Areas/Shared/{0}.cshtml",
                        "~/Views/{1}/{0}.cshtml"
                        "~/Views/Shared/{0}.cshtml",
                    }
                });
