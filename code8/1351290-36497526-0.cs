    if(isGrounded) {
            if(Input.GetKeyDown("space")) {
                if(isGrounded) 
                {
                rb.velocity = new Vector3(10, 15, 0);
                anim.Play("rig|Character_ActionsJUMP", -1, 0f); 
                anim.Play("Dress_Armature |Jump", 1, 0f); 
                anim.Play("Hair_Armature|Jump", 0, 0f); 
                isGrounded = false;
                }
                else if (!isGrounded && doubleJump) {
                rb.velocity = new Vector3(10, 15, 0);
                anim.Play("rig|Character_ActionsJUMP", -1, 0f); 
                anim.Play("Dress_Armature |Jump", 1, 0f); 
                anim.Play("Hair_Armature|Jump", 0, 0f); 
                doubleJump = false;
                }
            }
            }
