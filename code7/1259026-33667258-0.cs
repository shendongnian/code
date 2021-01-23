    private List<string> namesList;
    public class YourClass()
    {
        namesList = new List<string>();
    }
    private void addButton_Click(object sender, EventArgs e)
    {
         nameListBox.Add(addTextBox.Text);
    }
    private void sortListButton_Click(object sender, EventArgs e)
    {
         nameListBox.Sort();
    }
    private void searchButton_Click(object sender, EventArgs e)
    {
        string searchedString = nameListBox.FirstOrDefault(x => x.Contains(searchTextbox.Text);
    }
    private void deleteButton_Click(object sender, EventArgs e)
    {
         nameListBox.Remove(removeTextbox.Text);
    }
