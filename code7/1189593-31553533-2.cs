    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                AnimalDescription animalDescription = new AnimalDescription();
                animalDescription.Start();
            }
        }
        public class AnimalDescription
        {
            public string name { get; set; }
            public string description { get; set; }
            public string screenshotPrefix { get; set; }
            private int randomNumber;
            static List<AnimalDescription> animalDescriptions = new List<AnimalDescription>();
            public AnimalDescription()
            {
            }
            // Constructor to allocate string values
            public AnimalDescription(string newName, string newDescription, string newScreenshotPrefix)
            {
                name = newName;
                description = newDescription;
                screenshotPrefix = newScreenshotPrefix;
            }
            public void Start()
            {
                animalDescriptions.Add(new AnimalDescription(
                    name = "Of the Bear-Ape ARCTOPITHECUS.",
                    description = "There is in America a very deformed beast which the inhabitants call Haut or Hauti, and the Frenchmen, Guenon, " +
                    "as big as a great African Munkey. His belly hangeth very low, his head and face like unto a childs, as may be seen by " +
                    "this lively picture, and being taken it will fight like a young child. His skin is of an ash-colour, and hairy like a Bear; " +
                    "he hath but three claws on a foot, as long as four fingers, and like the thornes of Privet, where-by he climeth up into the " +
                    "highest trees, and for the most part liveth of the leaves of a certain tree being of an exceeding height, which the Americans " +
                    "call Amahut, and thereof this beast is called Haut. Their tail is about three fingers long, having very little hair there-on; " +
                    "I observed, that although it often rained, yet was that beast never wet.",
                    screenshotPrefix = "ARCTOPITHECUS_"
                    ));
                animalDescriptions.Add(new AnimalDescription(
                    
                    name = "Of the SIMIVULPA, or Apifb-Fox.",
                    description = "…they have seen a four-footed beast, the forepart like a Fox, and in the hinder part like an Ape, except that it had a mans " +
                    "feet, and ears like a Bat, and underneath the common belly, there was a skin like a bag or scrip, where-in she keepeth, lodgeth, " +
                    "and carryeth her young ones, until they are able to provide for themselves, without the help of their dam; neither do they come " +
                    "forth of that receptacle, except it be to suck milk, or sport themselves, so that the same under-belly is her best remedy against " +
                    "the furious Hunters, and other ravening beasts, to preserve her young ones, for she is incredibly swift, running with that carriage " +
                    "as if she has no burden. It hath a tail like a Munkey…",
                    screenshotPrefix = "SIMIVULPA_"
                    ));
                animalDescriptions.Add(new AnimalDescription(
                    name = "The SCYTHIAN WOLF.",
                    description = "…they have seen a four-footed beast, the forepart like a Fox, and in the hinder part like an Ape, except that it had a mans " +
                    "feet, and ears like a Bat, and underneath the common belly, there was a skin like a bag or scrip, where-in she keepeth, lodgeth, " +
                    "and carryeth her young ones, until they are able to provide for themselves, without the help of their dam; neither do they come " +
                    "forth of that receptacle, except it be to suck milk, or sport themselves, so that the same under-belly is her best remedy against " +
                    "the furious Hunters, and other ravening beasts, to preserve her young ones, for she is incredibly swift, running with that carriage " +
                    "as if she has no burden. It hath a tail like a Munkey…",
                    screenshotPrefix = "SCYTHIAN_WOLF_"
                    ));
                animalDescriptions.Add(new AnimalDescription(
                    name = "Of the TATUS, or Guinean Beast.",
                    description = "This is a four-footed strange Beast, it is naturally covered with a hard shell, divided and interlined like the fins of fishes, " +
                    "outwardly seeming buckled to the back like Coat-armor, within which the beast draweth up his body, as a Hedge-hog doth within his " +
                    "prickled skin; and therefore I take it to be a Brasilian Hedge-hog. It is not much greater than a little Pig, and by the snout, ears, " +
                    "legs, and feet thereof, it seemeth to be of that kind, saving that the snout is a little broader, and shorter than a Pigs, and the " +
                    "tail very long like a Lizards or Rats, and one of these being brought into France, did live upon the eating of seeds, and fruits of " +
                    "the Gardens, but it appeareth by that picture, or rather the stuffed, which Adriausus Mercellus the Apothecary…that the feet thereof " +
                    "are not cloven into two parts like Swine, but rather into many like Dogs, for upon the hinderfeet there are five toes, and upon the " +
                    "fore feet four, whereof two are so small that they are scarce visible. The breadth of that same skin was about seven fingers, and the " +
                    "length of it two spans, the shell or crust upon the back of it did not reach down unto the rump or tail, but broke off as it were upon " +
                    "the hips, some four fingers from the tail.",
                    screenshotPrefix = "TATUS_"
                    ));
                animalDescriptions.Add(new AnimalDescription(
                    name = "Of the GULON",
                    description = "This Beast was not known by the Ancients, but hath been since discovered in the Northern parts of the World, and because of the " +
                    "voracity thereof, it is called  (Gula)…is thought to be engendered by a Hyena and a Lioness, for the quality it resembleth a Hiena, " +
                    "and it is the same which is called (Crocuta;) it is a devouring and an unprofitable creature, having sharper teeth than other creatures. " +
                    "Some think it is derived of a Wolf and a Dog, for it is about the bigness of a Dog; it hath the face of Cat, the body and tail of a Fox; " +
                    "being black of colour; his feet and nails be most sharp, his skin rusty, the hair very sharp, and it feedeth upon dead carkases. When it " +
                    "hath found a dead carcass he eateth thereof so violently, that his belly standeth out like a bell; then he seeketh for some narrow passage " +
                    "betwixt two trees, and there draweth through his body, by pressing whereof, he driveth out the meat which he had eaten; and being so emptied " +
                    "returneth and devoureth as much as he did before, and goeth again and emptieth himself as in former manner; and so continueth eating and " +
                    "emptying till all be eaten.",
                    screenshotPrefix = "GULON_"
                    ));
                animalDescriptions.Add(new AnimalDescription(
                    name = "Of the SUCCORATH",
                    description = "…it is of a very deformed shape, and monstrous presence, a great ravener and untamable wilde Beast. When the Hunters that desire her " +
                    "skin set upon her, she flyeth very swift, carrying her young ones upon her back, and covering them with her broad tail: Hunters dig " +
                    "several pits or great holes in the earth, which they cover with boughs, sticks, and earth, so weakly that if the Beast chance at any " +
                    "time to come upon it, she and her young ones fall down into the pit and are taken. This cruel, untamable, impatient, violent, ravening, " +
                    "and bloudy beast, perceiving that her natural strength cannot deliver her from the wit and policy of men her hunters, (for being inclosed " +
                    "she can never get out again.)…she destroyeth them all with her own teeth; for there was never any of them taken alive…And this is all I " +
                    "finde recorded of this most savage Beast.",
                    screenshotPrefix = "SUCCORATH_"
                    ));
                RandomizeAnimals();
            }
            void RandomizeAnimals()
            {
                System.Random rand = new System.Random();
                foreach (AnimalDescription animalDescription in animalDescriptions)
                {
                    animalDescription.randomNumber = rand.Next();
                }
                animalDescriptions.Sort((firstObj, secondObj) =>
                {
                    return firstObj.randomNumber.CompareTo(secondObj.randomNumber);
                });
                //or
                //animalDescriptions = animalDescriptions.OrderBy(x => x.randomNumber).ToList();
            }
        }
    }
    ​
