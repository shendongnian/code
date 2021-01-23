        static void Main(string[] args)
        {
            // forced enum iteration
            for (int n = 0; n < 6; ++n)
            {
                var localInfoSet = Sdl.LanguagePlatform.Lingua.Locales.LocaleInfoSet.GetLocaleInfoSet((Sdl.LanguagePlatform.Lingua.Locales.LocaleSource)n);
                var tradLocaleInfo = localInfoSet.Where(item => item.Name.Contains("Traditional,"));
                foreach (var item in tradLocaleInfo)
                {
                    System.Diagnostics.Debug.WriteLine(item.Name);
                }
            }
        }
