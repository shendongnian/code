    using UnityEngine.UI;     // required for the text component
    public GameObject prefabCube;
    ...
    Vector3 cubePos = new Vector3(x, y, z);
    GameObject cube = (GameObject)Instantiate(prefabCube, cubePos, Quaternion.identity);
    cube.GetComponentInChildren<Text>().text = x + " " + y + " " + z;    // not quite sure if this line is correct
    cube.GetComponent<Renderer>().material.color = Color.blue;     // if all blocks have the same color, change this for the prefab directly
    // if you use an empty the last has to be
    cube.GetComponentInChildren<Renderer>().material.color = Color.blue;
