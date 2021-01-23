        private void ProcessSelectedObject(System.Collections.IList list)
        {
            foreach (object obj in list)
            {
                if (obj is Contact)
                {
                    if (((Contact)obj).Sector == null)
                    {
                        ((Contact)(obj)).Sector = "Default";
                    }
                }
            }
         }
