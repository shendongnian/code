            for (int i = Application.OpenForms.Count - 1; i > 1; i--)
            {
                // Here you are obtaining a reference to the form, but not using it
                Form1 f1 = Application.OpenForms[i] as Form1;
                // Here you are trying to Dispose, but then Close (instead of the other way around
                // I'm not sure why you'd do this unless you don't have cleanup being done at time of close.
                Application.OpenForms[i].Dispose();
                Application.OpenForms[i].Close();
                // It looks like your first form is the owner of every other form in the collection.
                // If possible, you may want to rethink this for clarity's sake.
                Application.OpenForms[1].RemoveOwnedForm(Application.OpenForms[i]);
            }
