    List<string> contacts = new List<string>();
    void OnCollisionEnter (Collision col)
    {
    	contacts.Add(col.gameObject.name);
    	if(contacts.Contains("object1") && contacts.Contains("object2"))
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionExit(Collision col)
    {
        contacts.Remove(col.gameObject.name);
    }
