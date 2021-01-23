    public void Reset()
    {
           var child = this as IChild;
            if (child != null && Model.Env1)
                Calc = child.CalcHeavy;
            else
                Calc = child.CalcLight;
    }
