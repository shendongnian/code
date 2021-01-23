    [System.Web.Http.AcceptVerbs("GET", "POST")]
        public void SaveLT()
        {
                var ls = ApplicationContext.Current.Services.LocalizationService;    
    
                //create a holder for the item's DictionaryTranslations
    
                List<DictionaryTranslation> _hello = new List<DictionaryTranslation>();
                List<DictionaryTranslation> _submit = new List<DictionaryTranslation>();
                List<DictionaryTranslation> _form = new List<DictionaryTranslation>();
                List<DictionaryTranslation> _bootstrap = new List<DictionaryTranslation>();
                List<DictionaryTranslation> _world = new List<DictionaryTranslation>();
                List<DictionaryTranslation> _heaven = new List<DictionaryTranslation>();
                List<DictionaryTranslation> _hell = new List<DictionaryTranslation>();
                List<DictionaryTranslation> _this = new List<DictionaryTranslation>();
                List<DictionaryTranslation> _sublime1 = new List<DictionaryTranslation>();
    
                 //the constructor for a DictionaryItem requires the Umbraco language object and value of the translated text                       
                 //so get the language object, eg from Iso Code                            
                var language = ls.GetLanguageByIsoCode("he-IL");
                var lang1 = ls.GetLanguageByIsoCode("ru");
                var lang2 = ls.GetLanguageByIsoCode("en-US");
    
                // here we create a french translation for our item and add it to the list    
                DictionaryTranslation hebhello = new DictionaryTranslation(language, "שלום");
                DictionaryTranslation rushello = new DictionaryTranslation(lang1, "Здравствуйте");
                DictionaryTranslation enghello = new DictionaryTranslation(lang2, "Blah");
                 _hello.Add(hebhello);
                 _hello.Add(rushello);
                 _hello.Add(enghello);
                 DictionaryTranslation hebsubmit = new DictionaryTranslation(language, "שלח");
                 DictionaryTranslation russubmit = new DictionaryTranslation(lang1, "Отправить");
                 DictionaryTranslation engsubmit = new DictionaryTranslation(lang2, "Submit");
                 _submit.Add(hebsubmit);
                 _submit.Add(russubmit);
                 _submit.Add(engsubmit);
                 DictionaryTranslation hebform = new DictionaryTranslation(language, "טופס");
                 DictionaryTranslation rusform = new DictionaryTranslation(lang1, "форма");
                 DictionaryTranslation engform = new DictionaryTranslation(lang2, "Form");
                 _form.Add(hebform);
                 _form.Add(rusform);
                 _form.Add(engform);
                 DictionaryTranslation hebbtstrp = new DictionaryTranslation(language, "אֹזֶן הַנַעַל");
                 DictionaryTranslation rusbtstrp = new DictionaryTranslation(lang1, "начальная загрузка");
                 DictionaryTranslation engbtstrp = new DictionaryTranslation(lang2, "Bootstrap");
                 _bootstrap.Add(hebbtstrp);
                 _bootstrap.Add(rusbtstrp);
                 _bootstrap.Add(engbtstrp);
                 DictionaryTranslation hebworld = new DictionaryTranslation(language, "עוֹלָם");
                 DictionaryTranslation rusworld = new DictionaryTranslation(lang1, "Мир");
                 DictionaryTranslation engworld = new DictionaryTranslation(lang2, "World");
                 _world.Add(hebworld);
                 _world.Add(rusworld);
                 _world.Add(engworld);
                 DictionaryTranslation hebheaven = new DictionaryTranslation(language, "גן העדן");
                 DictionaryTranslation rusheaven = new DictionaryTranslation(lang1, "небо");
                 DictionaryTranslation engheaven = new DictionaryTranslation(lang2, "Heaven");
                 _heaven.Add(hebheaven);
                 _heaven.Add(rusheaven);
                 _heaven.Add(engheaven);
                 DictionaryTranslation hebhell = new DictionaryTranslation(language, "גגֵיהִנוֹם");
                 DictionaryTranslation rushell = new DictionaryTranslation(lang1, "ад");
                 DictionaryTranslation enghell = new DictionaryTranslation(lang2, "Hell");
                 _hell.Add(hebhell);
                 _hell.Add(rushell);
                 _hell.Add(enghell);
                 DictionaryTranslation hebthis = new DictionaryTranslation(language, "זֶה");
                 DictionaryTranslation rusthis = new DictionaryTranslation(lang1, "это");
                 DictionaryTranslation engthis = new DictionaryTranslation(lang2, "This");
                 _this.Add(hebthis);
                 _this.Add(rusthis);
                 _this.Add(engthis);
                 DictionaryTranslation hebsub = new DictionaryTranslation(language, "נִשׂגָב");
                 DictionaryTranslation russub = new DictionaryTranslation(lang1, "возвышенный");
                 DictionaryTranslation engsub = new DictionaryTranslation(lang2, "Sublime");
                 _sublime1.Add(hebsub);
                 _sublime1.Add(russub);
                 _sublime1.Add(engsub);
                
                     //get or create a DictionaryItem, (passing in the Dictionary Key)                           
                IDictionaryItem hello = ls.DictionaryItemExists("hello_button") ? ls.GetDictionaryItemByKey("hello_button") : new DictionaryItem("hello_button");
                IDictionaryItem submit = ls.DictionaryItemExists("submit_button") ? ls.GetDictionaryItemByKey("submit_button") : new DictionaryItem("submit_button");
                IDictionaryItem form = ls.DictionaryItemExists("form_button") ? ls.GetDictionaryItemByKey("form_button") : new DictionaryItem("form_button");
                IDictionaryItem btstrp = ls.DictionaryItemExists("bootstrap_button") ? ls.GetDictionaryItemByKey("bootstrap_button") : new DictionaryItem("bootstrap_button");
                IDictionaryItem world = ls.DictionaryItemExists("world_button") ? ls.GetDictionaryItemByKey("world_button") : new DictionaryItem("world_button");
                IDictionaryItem heaven = ls.DictionaryItemExists("heaven_button") ? ls.GetDictionaryItemByKey("heaven_button") : new DictionaryItem("heaven_button");
                IDictionaryItem hell = ls.DictionaryItemExists("hell_button") ? ls.GetDictionaryItemByKey("hell_button") : new DictionaryItem("hell_button");
                IDictionaryItem This = ls.DictionaryItemExists("this_button") ? ls.GetDictionaryItemByKey("this_button") : new DictionaryItem("this_button");
                IDictionaryItem sublime = ls.DictionaryItemExists("sublime_button") ? ls.GetDictionaryItemByKey("sublime_button") : new DictionaryItem("sublime_button");
                 // set the translations created above    
                hello.Translations = _hello;
                submit.Translations = _submit;
                form.Translations = _form;
                btstrp.Translations = _bootstrap;
                world.Translations = _world;
                heaven.Translations = _heaven;
                hell.Translations = _hell;
                This.Translations = _this;
                sublime.Translations = _sublime1;
    
                 //now save the dictionary item and translations to Umbraco    
                UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
                var remove = new Sql("DELETE FROM cmsLanguageText");
                int rem = db.Execute(remove);
                ls.Save(hello);
                ls.Save(submit);
                ls.Save(form);
                ls.Save(btstrp);
                ls.Save(world);
                ls.Save(heaven);
                ls.Save(hell);
                ls.Save(This);
                ls.Save(sublime);
    
            
        }
