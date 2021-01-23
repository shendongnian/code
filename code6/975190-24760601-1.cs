        public List<TPer> getDATA<TPer>(TPer per, int acao)
        {
            List<TPer> lst = new List<TPer>();
            IDal dal;
            switch (per.GetType().Name)
            {
                case "Person": 
                    dal = new DalPerson();
                    break;
                case "Car":
                    dal = new DalCar();
                    break;
                default:
                    throw new InvalidOperationException("I dont like per");
            }
            lst = dal.getDATA(per, acao);
            return lst;
        }
