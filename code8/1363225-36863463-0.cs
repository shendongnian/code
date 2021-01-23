    public class Ticket
    {
        ...
       public string override ToString() { return getName(); }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
         ...
         //Load combobox
        foreach (Ticket t in events)
        {
            cbEvents.Items.Add(t);
        }
    }
