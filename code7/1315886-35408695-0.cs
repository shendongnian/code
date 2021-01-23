    public partial class Form1 : Form
    {
 	
	
    private List<Account> BankAccounts;
	
    public Form1()
    {
        InitializeComponent();
    }
    public void Form1_Load(object sender, EventArgs e)
    {
        BankAccounts = new List<Account>
        {
            new Account
            {
                ID = 345,
                Balance = 541.27
            },
            new Account
            {
                ID = 123,
                Balance = -127.44
            }
        };
    }
    public void button1_Click(object sender, EventArgs e)
    {
        ThisAddIn.DisplayInExcel(BankAccounts, (Account, cell) =>
        // This multiline lambda expression sets custom processing rules  
        // for the bankAccounts.
        {
            cell.Value = Account.ID;
            cell.Offset[0, 1].Value = Account.Balance;
            if (Account.Balance < 0)
            {
                cell.Interior.Color = 255;
                cell.Offset[0, 1].Interior.Color = 255;
            }
        });
    }
}
