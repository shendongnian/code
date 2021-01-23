        public void myMethod(int someInitializingParameter)
        {
            //return (kinda override operator)
            string sExtraData = "Hallo";
            if (TargetObjToinitItsProperties == null)
                throw new MyException("Property was accessed prior to parent object init",
                                      sExtraData);
            TargetObjToInitItsProperties.IntProp1 = someInitializingParameter;
        }
