    public GameObject[] cubes;
    
    void Start()
    {
    
    }
    
    private Color[] colors = { Color.red, Color.green, Color.yellow };
    
    void Update()
    {
        checkMouseClick();
    }
    
    
    void checkMouseClick()
    {
        MeshRenderer tempMR;
    
        //Check if mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                tempMR = hitInfo.collider.gameObject.GetComponent<MeshRenderer>();
    
                int cubeSize = cubes.Length;
    
                //Loop through all the cubes in in cubes array
                for (int i = 0; i < cubeSize; i++)
                {
                    //Check if any of them have a red color
                    if (cubes[i].GetComponent<MeshRenderer>().material.color == Color.red)
                    {
                        //if the cube we clicked is alread read, go ahead and generate a new color for it, else DONT CHANGE THE COLOR
                        if (cubes[i] == hitInfo.collider.gameObject)
                        {
    
                        }
                        else
                        {
                            return; //Exit if any cube has the red color
                        }
                    }
                }
    
                //No cube has a red color, change the color of clicked cube to a random color
                tempMR.material.color = colors[Random.Range(0, colors.Length)];
            }
        }
    }
