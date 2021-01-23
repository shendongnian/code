            Word.Application app = new Word.Application();
            int errors = 0;
            if (tx_article_title.Text.Length > 0)
            {
                app.Visible = false;
                // Setting these variables is comparable to passing null to the function.
                // This is necessary because the C# null cannot be passed by reference.
                object template = Missing.Value;
                object newTemplate = Missing.Value;
                object documentType = Missing.Value;
                object visible = true;
                // object visible = false;
                Word._Document doc1 = app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
                doc1.Words.First.InsertBefore(tx_article_title.Text);
                Word.ProofreadingErrors spellErrorsColl = doc1.SpellingErrors;
                errors = spellErrorsColl.Count;
                object optional = Missing.Value;
                doc1.Activate();
                this.Opacity = 0;
                //// get test form's handler
                //IntPtr hwnd = this.Handle;
                //// wait until the test form is the foreground window
                //while (true)
                //{
                //    if (GetForegroundWindow() == hwnd)
                //        break;
                //}
                //// Thread.Sleep(2000);
                // create a new thread to get the spelling check dialog
                /////////////////////////////////////////////////////////////////////////////////////////////////
                //Thread t = new Thread(new ThreadStart(GetSpellcheckingHandle));
                //t.Start();
                doc1.CheckSpelling(
                    ref optional, ref optional, ref optional, ref optional, ref optional, ref optional,
                    ref optional, ref optional, ref optional, ref optional, ref optional, ref optional);
                this.Opacity = 1;
                object first = 0;
                object last = doc1.Characters.Count - 1;
                tx_article_title.Text = doc1.Range(ref first, ref last).Text;
            }
            if (tx_author.Text.Length > 0)
            {
                app.Visible = false;
                // Setting these variables is comparable to passing null to the function.
                // This is necessary because the C# null cannot be passed by reference.
                object template = Missing.Value;
                object newTemplate = Missing.Value;
                object documentType = Missing.Value;
                object visible = true;
                // object visible = false;
                Word._Document doc1 = app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
                doc1.Words.First.InsertBefore(tx_author.Text);
                Word.ProofreadingErrors spellErrorsColl = doc1.SpellingErrors;
                errors = spellErrorsColl.Count;
                object optional = Missing.Value;
                doc1.Activate();
                this.Opacity = 0;
                //// get test form's handler
                //IntPtr hwnd = this.Handle;
                //// wait until the test form is the foreground window
                //while (true)
                //{
                //    if (GetForegroundWindow() == hwnd)
                //        break;
                //}
                //// Thread.Sleep(2000);
                // create a new thread to get the spelling check dialog
                /////////////////////////////////////////////////////////////////////////////////////////////////
                //Thread t = new Thread(new ThreadStart(GetSpellcheckingHandle));
                //t.Start();
                doc1.CheckSpelling(
                    ref optional, ref optional, ref optional, ref optional, ref optional, ref optional,
                    ref optional, ref optional, ref optional, ref optional, ref optional, ref optional);
                this.Opacity = 1;
                object first = 0;
                object last = doc1.Characters.Count - 1;
                tx_author.Text = doc1.Range(ref first, ref last).Text;
            }
            if (tx_region.Text.Length > 0)
            {
                app.Visible = false;
                // Setting these variables is comparable to passing null to the function.
                // This is necessary because the C# null cannot be passed by reference.
                object template = Missing.Value;
                object newTemplate = Missing.Value;
                object documentType = Missing.Value;
                object visible = true;
                // object visible = false;
                Word._Document doc1 = app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
                doc1.Words.First.InsertBefore(tx_region.Text);
                Word.ProofreadingErrors spellErrorsColl = doc1.SpellingErrors;
                errors = spellErrorsColl.Count;
                object optional = Missing.Value;
                doc1.Activate();
                this.Opacity = 0;
                //// get test form's handler
                //IntPtr hwnd = this.Handle;
                //// wait until the test form is the foreground window
                //while (true)
                //{
                //    if (GetForegroundWindow() == hwnd)
                //        break;
                //}
                //// Thread.Sleep(2000);
                // create a new thread to get the spelling check dialog
                ///////////////////////////////////////////////////////////////////////////////////////////////
                Thread t = new Thread(new ThreadStart(GetSpellcheckingHandle));
                t.Start();
                doc1.CheckSpelling(
                    ref optional, ref optional, ref optional, ref optional, ref optional, ref optional,
                    ref optional, ref optional, ref optional, ref optional, ref optional, ref optional);
                this.Opacity = 1;
                object first = 0;
                object last = doc1.Characters.Count - 1;
                tx_region.Text = doc1.Range(ref first, ref last).Text;
            }
           
            object saveChanges = false;
            object originalFormat = Missing.Value;
            object routeDocument = Missing.Value;
            app.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
            MessageBox.Show("SpellCheck completed!");
            this.Activate();
        }
        /// <summary>
        /// get the spelling check handle
        /// </summary>
        public void GetSpellcheckingHandle()
        {
            int i = FindWindow("bosa_sdm_msword", (int)IntPtr.Zero);
            while (i != 0)
            {
                // bring the spelling check dialog to the front.
                BringToFront("bosa_sdm_msword", (int)IntPtr.Zero);
            }
        }
    }
