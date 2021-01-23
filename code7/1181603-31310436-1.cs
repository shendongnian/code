        delegate bool DoMyThingsAction();
        DoMyThingsAction[,] doMyThings;
        public void InitializeDoMyThings()
        {
            doMyThings = new DoMyThingsAction[10, 10]; // number of actions and type
            doMyThings[0, 0] = Type1_Ac1;
            // and so on
        }
