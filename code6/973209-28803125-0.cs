    public static void closeAll()
       {
             FormCollection fc = Application.OpenForms;
             if (fc != null && fc.Count > 1)
             {
                int fixedCount = fc.Count;
                for (int i = (fixedCount - 1); i > 0; i--)
                {
                    Form selectedForm = Application.OpenForms[i];
                    selectedForm.Close();
                }
            }
        }
