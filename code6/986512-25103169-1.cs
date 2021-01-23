    void Alpha()
    {
        Destroy(Cubes[aux]);
        AddCube(aux2,Map[aux]);
        ChangeColor(aux2);
        Map[aux]=0;
        Semafor = true;
    }
    
    void MoveCube(int Initial,int Final)
    {
        Semafor = false;
        EmptySpaces.Remove(Final);
        EmptySpaces.Add (Initial);
        LTDescr d = LeanTween.move(Cubes[Initial],new Vector3(PosX[Final],PosY[Final],5),0.5f);
        d.setOnComplete(Alpha);
        aux = Initial; // auxiliar variables used because I don't know how to send params through Invoke
        aux2 = Final;
    
    }
