    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ATM
    {
        class Account
        {
            string firstName, lastName, dateOfBirth, phoneNO, fathersName, mothersName;
            double initialBalance; 
            int pinNo, accountNo, age; 
            DateTime yearOfBirth;
    
            public Account() 
            {
                pinNo = 100;
                accountNo = 1234;
            }
    
            public string FirstName
            {
                get { return this.firstName; }
                set
                {
                    if (string.IsNullOrEmpty(value)) throw new Exception();
                    else firstName = value;
                }
            }
            public string LastName
            {
                get { return this.lastName; }
                set
                {
                    if (string.IsNullOrEmpty(value)) throw new Exception();
                    else lastName = value;
                }
            }
            public string DateOfBirth
            {
                get { return this.dateOfBirth; }
                set
                {
                    if (string.IsNullOrEmpty(value)) throw new Exception();
                    else dateOfBirth = value;
                }
            }
            public string PhoneNo
            {
                get { return this.phoneNO; }
                set
                {
                    if ((string.IsNullOrEmpty(value)) || value.Length != 10)
                        throw new Exception();
                    else
                        phoneNO = value;
                }
            }
            public string FathersName
            {
                get { return this.fathersName; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception();
                    else
                        fathersName = value;
                }
            }
            public string MothersName
            {
                get { return this.mothersName; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception();
                    else
                        mothersName = value;
                }
            }
            public double InititailBalance
            {
                get { return this.initialBalance; }
                set
                {
                    if (double.IsNaN(value))
                        throw new Exception();
    
                    else
                        initialBalance = value;
                }
            }
            public int PinNo
            {
                get { return this.pinNo; }
            }
            public int AccountNo
            {
                get { return this.accountNo; }
            }
            public void GenerateAccount()
            {
                // code for asking user for their details.
            }
        }
    
    
        class ATM
        {
            public static Dictionary<int, Account> AccountsList;
    
            static ATM() 
            {
                AccountsList = new Dictionary<int, Account>();
            }
    
            public void CreateAccount()
            {
                Account acc = new Account();
                acc.GenerateAccount();
                AccountsList.Add(acc.AccountNo, acc);
            }
    
            public void Deposit()
            {
                Console.WriteLine("Enter your account number");
                int accountNo = int.Parse(Console.ReadLine());
    
                if (AccountsList.ContainsKey(accountNo))
                {
                    Console.WriteLine("Enter your amount you wish to deposit");
                    int amount = int.Parse(Console.ReadLine());
                    AccountsList[accountNo].InititailBalance += amount;
                }
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                ATM atm = new ATM();
                while (true)
                {
                    Console.WriteLine("Menu");
                    Console.WriteLine("1.Create Account");
                    Console.WriteLine("2.ATM");
                    Console.Write("Please enter your selections: ");
                    int select = int.Parse(Console.ReadLine());
    
                    switch (select)
                    {
                        case 1:
                            atm.CreateAccount();
                            break;
    
                        case 2:
                            atm.Deposit();
                            break;
                        default:
                            Console.WriteLine("Invalid selection!");
                            break;
                    }
                }
            }
        }
    }
