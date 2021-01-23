    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace BankForm
    {
        public partial class BankForm : Form
        {
            public BankForm()
            {
                InitializeComponent();
                _myAccount = new BankAccount();
            }
            private BankAccount _myAccount;
            private void initialDepositButton_Click(object sender, EventArgs e)
            {
                _myAccount.SavingsAccount = Convert.ToInt32(initialDepositTextBox.Text);
                bankAccountListBox.Text = "Account opened with initial Deposit " + initialDepositTextBox.Text;
            }
        }
        class BankAccount
        {
            // *PROPERTIES* 
            private int _initialDeposit = 0;
            // **ACCESSORS** 
            public int SavingsAccount
            {
                set
                {
                    _initialDeposit = value;
                }
                get
                {
                    return _initialDeposit;
                }
            }
        }
    }
    ​
