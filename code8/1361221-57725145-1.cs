    void AnimTrigger(string triggerName)
     {
         foreach(AnimatorControllerParameter p in animator.parameters)
             if (p.type == AnimatorControllerParameterType.Trigger)
                 animator.ResetTrigger(p.name);
         animator.SetTrigger(triggerName);
     }
