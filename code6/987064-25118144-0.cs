      public string GetSelectedValues()
        {
            string selectedVal = string.Empty;
            int i = 0;
            foreach (int index in lstbox.GetSelectedIndices())
            {
                if (i == 0) 
                   selectedVal = lstbox.Items[index].Value;
                else
                  selectedVal = selectedVal + ";" + lstbox.Items[index].Value.ToString();
                i++;
            }
            return selectedVal ;
        }
