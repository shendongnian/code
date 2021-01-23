    var systemRepo = new SystemRepository();
    var allSystems = systemRepo.GetAll();
    for (int i = 0; i < allSystems.Count(); i++)
    {
        allSystems[i].worldPos = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(minZ, maxZ));
        Instantiate(systemObject, allSystems[i].worldPos, Quaternion.identity);
    }
