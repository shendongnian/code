     MyInfoClass temp = (MyInfoClass)this.MemberwiseClone();
     temp._mySystems = new ObservableCollection<MySystems>();
     foreach (MySystem sys in _mySystems)
     {
         temp.AddSys(sys);
     }
     return temp;
