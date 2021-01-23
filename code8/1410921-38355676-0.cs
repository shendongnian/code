        foreach (var element in list)
        {
            if (!element.IsPicked)
            {
                foreach(var grandChild in element)
                {
                    foreach(var greatGrandChild in grandChild)
                    {
                        greatGrandChild.GetComponent<Image>().enabled = false;
                    }
                }          
            }
        }
