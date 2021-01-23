            //put this at class level
            bool _parentClosed;
            //put this in controls constructor
            //when control first becomes visible
            this.VisibleChanged += (s1, a1) =>
            {
                //find parent Form (not the same as Parent)
                Form form = this.FindForm();
                //If we are on a Form
                if (form != null)
                    //subscribe to it's closing event
                    form.Closing += (s2, a2) => { _parentClosed = true; };
                else
                    throw new Exception("How did we become visible without being on a Form?");
            };
