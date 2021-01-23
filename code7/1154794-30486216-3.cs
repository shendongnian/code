    double TotalDebts = 30000;
    list<Tuple<int, double>> AllDebits = new list<Tuple<int, double>>();
    for (int i = 0; i < 250; i++)
    {
        if (TotalDebts > 0)
        {
            double DebtsLessIncome = Convert.ToDouble(TotalDebts - 1000);
            double InterestCharged = Convert.ToDouble((DebtsLessIncome * 5) / 100);
            double InterestDebt = Convert.ToDouble(DebtsLessIncome + InterestCharged);
            double InterestDebtMLE = Convert.ToDouble(InterestDebt + 500);
            TotalDebts = Convert.ToDouble(InterestDebtMLE);
            AllDebits.Add(new Tuple<int,double>(i, TotalDebts));
        }
    }
