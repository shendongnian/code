    void OnTriggerEnter(Collider other)
        {
            var air = other.GetComponent<Collider>().gameObject.GetComponent<DamageManager>();
        
            if (air)
            {
                air.HP += HPFill;
            }
        }
