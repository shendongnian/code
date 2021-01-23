    using UnityEngine;
    using UnityEngine.UI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Parse;
    
    public class RetrieveAllObjects : MonoBehaviour
    {
    	public RectTransform InfoCell;
    	public Text IdText;
    	public Text DateText;
    	public float Vec3x;
    	public float Vec3y;
    	public List<string>AllObjectIds = new List<string> ();
    	public List<string>CreatedAtDates = new List<string> ();
    	public GameObject AnchorPos;
    	int num;
    	string objectId;
    	DateTime? createdAt;
    	IEnumerable<ParseObject> results;
    
    	// Use this for initialization
    	void Start ()
    	{
    
    		var query = ParseObject.GetQuery ("Snapshot")
    			.OrderByDescending("createdAt");
    
    		query.FindAsync ().ContinueWith (u =>
    		{
    			results = u.Result;
    			foreach (var result in results) {
    				objectId = result.ObjectId;
    				createdAt = result.CreatedAt;
    
    				// print ("Object ID: " + objectId + "\n" + "Date Created: " + createdAt);
    
    				AllObjectIds.Add (objectId);
    				CreatedAtDates.Add (createdAt.ToString());
    			}
    
    			foreach (string id in AllObjectIds) {
    				// CreateInfoCell ();
    				// print (id);
    			}
    			foreach (string date in CreatedAtDates) {
    				// CreateInfoCell ();
    				// print (date);
    			}
    			return AllObjectIds;
    			return CreatedAtDates;
    		});
    
    		StartCoroutine (UpdateUI ());
    	}
    
    	IEnumerator UpdateUI () {
    		yield return new WaitForSeconds(1);
    		var query = ParseObject.GetQuery ("Snapshot");
    		Task task = query.FindAsync ();
    		while(!task.IsCompleted) yield return null;
    		// Do all your continue with stuff here
    		foreach (string id in AllObjectIds) {
    			CreateInfoCell (id);
    		}
    		AnchorPos.SetActive (false);
    	}
    
    	void CreateInfoCell (string id)
    	{
    			// print ("CELL CREATED\n");
    			RectTransform newCell = Instantiate (InfoCell);
    			newCell.name = id + " - " + CreatedAtDates[num];
    			GameObject PutIdText = GameObject.Find(newCell.name + "/ObjectIdText");
    			PutIdText.GetComponent<Text> ().text = id;
    			GameObject PutDateText = GameObject.Find(newCell.name + "/DateCreatedText");
    			PutDateText.GetComponent<Text> ().text = CreatedAtDates[num];
    
    		StartCoroutine (DisplayThumbnail(newCell, id));
    
    			// IdText.text = id;
    			// DateText.text = CreatedAtDates[num];
    			num++;
    			newCell.transform.SetParent (this.gameObject.transform);
    			newCell.transform.localScale = new Vector3 (1, 1, 1);
    		newCell.transform.position = new Vector3 (AnchorPos.transform.position.x, AnchorPos.transform.position.y - Vec3y, AnchorPos.transform.position.z);
    			Vec3y = Vec3y + 100;
    	}
