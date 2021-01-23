    void CannonKiller()
    {
        // Grab colliders in vicinity of explosion
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 4);
        foreach (Collider hitCollider in hitColliders){
            
            // Only act if collider belongs to an enemy cannon
            if (hitCollider.gameObject.tag == "EnemyCannon"){
                Destroy(hitCollider.gameObject);
                // If there are no non-null references to cannon objects, they're all destroyed
                if (enemyCans.FirstOrDefault(cannon => cannon != null) == null){
                    // Execute finishing code, then probably break
                }
            }
        }
    }
