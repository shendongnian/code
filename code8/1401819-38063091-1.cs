    using UnityEngine;
    using System.Collections.Generic;
    using UnityEngine.UI;
    
    public class spawnmanager : MonoBehaviour {
    public int noOfobjects = 6;
    public Transform[] spawnPoints;  
    public GameObject normalCrate;
    public GameObject specialCrate;
    public float speiclaCratePercentageMin;
    public float speiclaCratePercentageMax;
    void Awake()
    {
    }
    
    // Use this for initialization
    void Start () 
    {
        spawner();
    }
    void spawner ()
    {
        List<Transform> availablePoints = new List<Transform>(spawnPoints);
        //Figures out how many special creates we need.
        int numberOfSpecialCrates = noOfobjects * Random.Range(this.speiclaCratePercentageMin, this.speiclaCratePercentageMax);
        //Added i<spawnPoints.Length check to prevent errors when noOfobjects is bigger than the number of available spawn points.
        for (int i = 0; i<noOfobjects && i<spawnPoints.Length;i++)
        {    
            int spawnPointIndex = Random.Range (0, availablePoints.Count);
    
            //As long as i is lower than numberOfSpecialCrates we spawn a special crate.
            if(i < numberOfSpecialCrates)
            {
                Debug.Log("dd");
                Instantiate(specialCrate, availablePoints[spawnPointIndex].position, Quaternion.identity);
            } 
            else
            {
                Instantiate(normalCrate, availablePoints[spawnPointIndex].position, Quaternion.identity) ;
            }     
    
            availablePoints.RemoveAt(spawnPointIndex);
        }
    }
    }
