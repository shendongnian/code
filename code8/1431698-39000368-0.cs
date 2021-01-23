    public Rigidbody objectToRotate;
    IEnumerator startRotating()
    {
        float startingSpeed = 10f;
        const float maxSpeed = 400; //The max Speeed of startingSpeed
    
        while (true)
        {
            while (Input.GetKey(KeyCode.LeftArrow))
            {
                if (startingSpeed < maxSpeed)
                {
                    startingSpeed += Time.deltaTime;
                }
                Quaternion rotDir = Quaternion.Euler(new Vector3(0, 1, 0) * -(Time.deltaTime * startingSpeed));
                objectToRotate.MoveRotation(objectToRotate.rotation * rotDir);
                Debug.Log("Moving Left");
                yield return null;
            }
    
            startingSpeed = 0;
    
            while (Input.GetKey(KeyCode.RightArrow))
            {
                if (startingSpeed < maxSpeed)
                {
                    startingSpeed += Time.deltaTime;
                }
                Quaternion rotDir = Quaternion.Euler(new Vector3(0, 1, 0) * (Time.deltaTime * startingSpeed));
                objectToRotate.MoveRotation(objectToRotate.rotation * rotDir);
                Debug.Log("Moving Right");
                yield return null;
            }
            startingSpeed = 0;
            yield return null;
        }
    }
