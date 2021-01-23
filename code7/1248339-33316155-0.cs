          IInitiatorUnit A = new InitiatorUnit("A");
            IUnit B = new Unit("B");
            IUnit C = new Unit("C");
            B.RegisterUnit(A); // B is listening to A
            C.RegisterUnit(B); // C is listening to B
            A.RegisterUnit(C); //  A is listinig to C
     void heartBeatTimer_Tick(object sender, EventArgs e)
        {
            A.GenerateResource(1); // Start the process
        }
