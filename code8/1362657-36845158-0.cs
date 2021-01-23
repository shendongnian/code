    using UnityEngine;
    using System.Collections;
    
    public class buttons_abc : MonoBehaviour {
    public int id;
    public GameObject[] letters;
    
    // Use this for initialization
    void Start () {
        id = 0;
        //Already declared letters globally. Creating another one here locally will mean that your global array will not be populated
        //GameObject[] letters = GameObject.FindGameObjectsWithTag ("letter");
        letters = GameObject.FindGameObjectsWithTag ("letter");
        letters[id].SetActive (true);
        for (int i = 1; i < 32; i++) {
            letters[i].SetActive (false);
        }
    
    }
    public void nextItem(){
        //GetComponent only works on Components. GameObjects are NEVER components
        //GetComponent cannot return an array
        //letters = GetComponent<GameObject[]>();
        Debug.Log (id);
        if(id < 32){
            letters[id].SetActive (false);
            letters[id + 1].SetActive (true);
            id++;
        } else {
            Debug.Log("viimane t2ht");
        }
    }
    public void prevItem(){
        //See comment from nextItem()
        //letters = GetComponent<GameObject[]>();
        Debug.Log (id);
            if(id > 0){
    
                letters[id].SetActive(false);
                letters[id-1].SetActive(true);
                id--;
            } else{
                Debug.Log("esimene t2ht");
            }
    } }
 
