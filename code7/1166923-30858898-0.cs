        private void ValidateListBoxes()
        {
            List<ListBox> listBoxes = new List<ListBox>();
            listBoxes.Add(listBoxEmails);
            listBoxes.Add(listBoxWebsites);
            listBoxes.Add(listBoxComments);
            bool isContainingEmptyList = listBoxes.Any(l => l.Items.Count < 1 || l.Items.Count==0);
        }
