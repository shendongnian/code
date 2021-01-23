       public ObjectTypeA OBJ1 = new ObjectTypeA();
       public ObjectTypeA OBJ1 = new ObjectTypeB();
       
       main() 
       {
           DoStuff(OBJ1);
           DoStuff(OBJ2);
       }
       public void DoStuff(ObjectTypeA _obj)
       {
           // I know this object has this property.  
           _obj.Prop1 = true;
       }
