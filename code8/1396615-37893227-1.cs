    using UnityEngine;
    using System.Collections;
    public class clear : MonoBehaviour {
    TimingForIndust2 timingForIndust2;
    
    ParticleSystem particles;
     
    // Use this for initialization
    void Start () {
        particles = GetComponent<ParticleSystem> ();
        particles.emissionRate = 0;
    
        GameObject tempObj = GameObject.Find("Timer");
        timingForIndust2 = tempObj.GetComponent<TimingForIndust2>();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown (1)) {
            particles.Emit (10);
        }
    }
    void OnParticleCollision(GameObject obj)
    {
        if (obj.CompareTag("fire1")) {
            Destroy (obj, 5.0f);
            timingForIndust2.stars ();
        }
            StartCoroutine (TestCoroutine());
        }
    IEnumerator TestCoroutine(){
        yield return new WaitForSeconds(8);
        Application.LoadLevel (25);
    }
    }
