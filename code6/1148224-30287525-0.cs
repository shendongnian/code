    update()
    {
            Vector3 dir = new Vector3(); //(0,0,0)
            //float CharacterSpeed = 10.0f;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                dir.z += 1.0f;
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                dir.x -= 1.0f;
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                dir.z -= 1.0f;
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                dir.x += 1.0f;
            dir.Normalize();
            transform.Translate(dir * CharacterSpeed * Time.deltaTime);
    }
