            //put this at class level
            bool _parentClosed;
            //put this in controls constructor
            
            //when parent changes 
            c.ParentChanged+= (s1, a1) =>
            {
                //reset parent closing flag
                _parentClosed = false;
                //find parent Form (not the same as Parent)
                Form form = c.FindForm();
                //If we are on a Form
                if(form != null)
                    form.Closing += (s2, a2) => { _parentClosed = true; };    //subscribe to it's closing event
            };
            
            
