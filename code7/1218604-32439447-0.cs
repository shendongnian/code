    public GameObject thing_maker(string gameobject_name, string sprite_name, string rg_body_name)
    {
        GameObject go = new GameObject(gameobject_name);
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>(sprite_name);
        Rigidbody rb = go.AddComponent<Rigidbody>();
        /* now if you want to change values of the components you can just do it
           by accesing them directly. for instance: rb.isKinematic = true; will
           change the isKinematic value of this rigidbody to true. */
        return go;
    }
