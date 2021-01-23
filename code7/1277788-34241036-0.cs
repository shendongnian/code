        public void myMethod(int someInitializingParameter)
        {
            //return (kinda override operator)
            if(TargetObjToinitItsProperties == null)
                throw new Exception("Property was accessed prior to parent object init");
            TargetObjToInitItsProperties.IntProp1 = someInitializingParameter;
        }
