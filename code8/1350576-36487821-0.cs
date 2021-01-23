    using UnityEngine;
    using System.Collections;
    public class FollowPlayerCamera : MonoBehaviour {
    public float smoothSpeed = 2f;
    GameObject player;
    // Use this for initialization
    void Start () {
    player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void LateUpdate () {
    transform.position = Vector3.Slerp(transform.position, new Vector3(player.transform.position.x, transform.position.y, transform.position.z), smoothSpeed * Time.deltaTime); 
    }
    }
