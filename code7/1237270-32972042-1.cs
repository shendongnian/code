    public void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        { 
            case "Pick Up": other.gameObject.SetActive(false);
                break;
            case "Lava": Die();
                break;
        }
    }
