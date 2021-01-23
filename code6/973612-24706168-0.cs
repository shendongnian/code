     private void Testit()
        {
            var a = SavingsAccount.Factory();
            var c = CheckingAccount.Factory();
            //var b = BankAccount.Factory(); //can't do this
        }
    
    public class BankAccount<T> where T : BankAccount<T>, new()
    {
        public static T Factory()
        {
            return new T();
        }
    }
    public class SavingsAccount : BankAccount<SavingsAccount>
    {
    }
    public class CheckingAccount : BankAccount<CheckingAccount>
    {
    }
