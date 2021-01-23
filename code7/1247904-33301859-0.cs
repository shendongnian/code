    public class PLCVars
    {
        public bool PLCVar1;
        public bool PLCVar2;
        public bool PLCVar3;
        public bool PLCVar4;
        public bool PLCVar5;
        public bool PLCVar6;
        public bool PLCVar7;
        public bool PLCVar8;
        public bool[] BooleanVars()
        {
            return new bool[] { PLCVar1, PLCVar2, PLCVar3, PLCVar4, PLCVar5 };
        }
    }
    public void Method()
    {
         PLCVars v = new PLCVars();
         panel1.Controls.Clear();
         for (int i = 1; i < 5; i++)
         {
             Button button = new Button();
             button.Name = "Button" + i;
             button.MouseUp += delegate 
             {
                 v.BooleanVars()[i] = false;
             };
             button.MouseDown += delegate
             {
                 v.BooleanVars()[i] = true;
             };
             panel1.Controls.Add(button);
         }
    }
