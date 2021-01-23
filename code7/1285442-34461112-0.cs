    using UnityEngine;
    using System.Collections;
    
    public class BoneHiglighter : MonoBehaviour {
    
    	public Color32 highlightColor = Color.red;
    	public Color32 regularColor = Color.white;
    
    	public SkinnedMeshRenderer smr;
    
    	// Just for sake of demonstration
    	public Transform bone;
    	private Transform prevBone;
    
    
    	// Find bone index given bone transform
    	int GetBoneIndex(Transform bone) {
    		Debug.Assert(smr != null);
    		var bones = smr.bones;
    
    		for (int i = 0; i < bones.Length; ++i) {
    			if (bones[i] == bone) return i;
    		}
    
    		return -1;
    	}
    
    	// Change vertex colors highlighting given bone
    	void Highlight(Transform bone) {
    		Debug.Assert(smr != null);
    		var idx = GetBoneIndex(bone);
    		var mesh = smr.sharedMesh;
    		var weights = mesh.boneWeights;
    		var colors = new Color32[weights.Length];
    
    		for (int i = 0; i < colors.Length; ++i) {
    			float sum = 0;
    			if (weights[i].boneIndex0 == idx && weights[i].weight0 > 0)
    				sum += weights[i].weight0;
    			if (weights[i].boneIndex1 == idx && weights[i].weight1 > 0)
    				sum += weights[i].weight1;
    			if (weights[i].boneIndex2 == idx && weights[i].weight2 > 0)
    				sum += weights[i].weight2;
    			if (weights[i].boneIndex3 == idx && weights[i].weight3 > 0)
    				sum += weights[i].weight3;
    
    			colors[i] = Color32.Lerp(regularColor, highlightColor, sum);
    		}
    
    		mesh.colors32 = colors;
    
    	}
    
    	void Start() {
    		// If not explicitly specified SkinnedMeshRenderer try to find one
    		if (smr == null) smr = GetComponent<SkinnedMeshRenderer>();
    		// SkinnedMeshRenderer has only shared mesh. We should not modify it.
    		// So we make a copy on startup, and work with it.
    		smr.sharedMesh = (Mesh)Instantiate(smr.sharedMesh);
    
    		Highlight(bone);
    	}
    
    	void Update() {
    		if (prevBone != bone) {
    			// User selected different bone
    			prevBone = bone;
    			Highlight(bone);
    		}
    	}
    }
