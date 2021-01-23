    public void boom()
    {
            if (iBlowedUp == true) 
            {
                iBlowedUp = false;
                StartCoroutine (waitForIt ());
                Destroy (tf);
                tfpf = Instantiate (Resources.Load ("Prefabs/tfpf")) as GameObject;
            }
    }
