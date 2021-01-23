    int value =10;
    protected void BtnIncre_Click(...)
    {
    if(value<=80){
    value+=10;
    Session["value"]=value;
    }
    } 
    protected void BtnDecre(...)
     {
    if(value>=10)
     {
    value-=10;
    Session["Value"]=value;
     }
    }
