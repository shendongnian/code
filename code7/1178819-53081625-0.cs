    bool IsTime(string myValue) {
        bool Succeed = true;
        try {
            DateTime temp = Convert.ToDateTime(myValue);
        }
        catch (Exception ex) {
            Succeed = false;
        }
        
        return Succeed;
    }
