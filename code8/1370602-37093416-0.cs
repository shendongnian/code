        private void setObj(Type type)
        {
            myObj = Objects.Single(o => o.GetType() == type);
        }
        public void Switch()
        {
            Type setToThisType = myObj.GetType();
            setObj(setToThisType);
        }
