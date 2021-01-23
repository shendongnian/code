    // global var
    List<GameObject> objs = new List<GameObject>();
    // inside function
    GameObject blueIns = Instantiate(bluePlane) as GameObject;
    objs.Add(blueIns);
    GameObject testEn = Instantiate (testEnemy) as GameObject;
    objs.Add(testEn);
